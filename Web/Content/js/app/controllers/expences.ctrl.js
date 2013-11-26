function ExpencesCtrl($scope, $q, $modal, $timeout, $stateParams, $state, $log, CategoriesRepository, ExpencesRepository) {

    var categories, skip, take;

    var init = function () {
        $log.debug('Initializing Expences.ctrl');

        skip = 0;
        take = 20;

        initOperations();
        resetNewExpence();
        categories = CategoriesRepository.query();
        reloadExpences();

        $scope.add = addExpence;
        $scope.filterCategories = filterCategories;
        $scope.loadMoreExpences = loadMoreExpences;
        $scope.delete = deleteExpence;
        $scope.edit = editExpence;
        $scope.updateExpence = updateExpence;
        $scope.closeEditDialog = closeEditDialog;

        $log.debug('Controller initialized.');
    }

    var initOperations = function () {
        $scope.operations = {
            add: {
                status: 'idle',
                text: 'Add',
                start: function () {
                    status = 'in progress';
                    //text = 'Wait...';
                },
                finish: function () {
                    status = 'idle';
                    //text = 'Add';
                }
            }
        };
    }

    var resetNewExpence = function () {
        $scope.newExpence = {
            Id : -1,
            Date: new Date()
        };

        $scope.addCommandStatus = 'ok';
    }

    var clearForm = function () {
        resetNewExpence();
        $scope.formNewExp.$setPristine();
    }

    var findCategoryByName = function (categoryName) {
        for (var i = 0; i < categories.length; i++) {
            if (categories[i].Name == categoryName) {
                return categories[i];
            }
        }

        return null;
    }

    var filterCategories = function (query) {
        return $.map(categories, function (category) {
            return category.Name;
        });
    }

    var updateCategoriesList = function (category) {
        categories.push(category);
        categories.sort(function (a, b) {
            return (a.Name < b.Name) ? -1 : ((a.Name > b.Name) ? 1 : 0);
        });
    }

    var addExpence = function (expence) {
        $scope.operations.add.start();

        getCategoryAsync(expence.Category)
            .then(function (category) {
                expence.CategoryId = category.Id;
                return expence;
            })
            .then(createOrUpdateExpenceAsync)
            .then(function (data) {
                clearForm();
                reloadExpences();
                $scope.operations.add.finish();
            }, function (reason) {
                $scope.addCommandStatus = 'failed';
                $scope.operations.add.finish();
            });
    }

    var getCategoryAsync = function (categoryName) {
        return $timeout(function () {
            var category = findCategoryByName(categoryName);
            if (category != null) {
                return category;
            } else {
                category = {
                    Name: categoryName
                };

                return CategoriesRepository.create(category).$promise.then(function (data) {
                    updateCategoriesList(category);
                    return data;
                })
            }
        }, 0);
    }

    var createOrUpdateExpenceAsync = function (expence) {
        if (expence.Id == -1) {
            return ExpencesRepository.create(expence).$promise;
        } else {
            return ExpencesRepository.update(expence).$promise;
        }
    }

    var reloadExpences = function () {
        queryExpences(0, skip + take).then(setExpences);
    }

    var queryExpences = function (skip, take) {
        $log.debug("Querying expences: skip = '" + skip + "', take = '" + take + "', period = '" + $stateParams.periodType + "'");

        return ExpencesRepository.query( {
                skip: skip,
                take: take,
                period: $stateParams.periodType
            }, function (data, headers) {
                $log.debug("Query succeeded.");

                $scope.hasMore = (headers('BK-HasMore') || 'false').toLowerCase() === 'true';
            }).$promise;
    }

    var loadMoreExpences = function () {
        skip += take;
        queryExpences(skip, take).then(joinExpences);
    }

    var joinExpences = function (data) {
        $scope.expences = $scope.expences.concat(data);
    }

    var setExpences = function (data) {
        $scope.expences = data;
    }

    var deleteExpence = function (id) {
        if (confirm('Are you sure?')) {
            ExpencesRepository.delete({ 'id': id }).$promise.then(
                function (data) {
                    reloadExpences();
                },
                function (reason) {
                    alert('An error occured during deletion of this expence. Try again later.');
                });
        }
    }

    var masterExpence;
    var activePeriodType;
    var editExpence = function (expence) {
        masterExpence = expence;
        $scope.selectedExpence = JSON.parse(JSON.stringify(masterExpence)); // clone

        // Create modal (returns a promise since it may have to perform an http request)
        var modalPromise = $modal({ template: '/expEditModal', persist: true, show: false, backdrop: 'static', scope: $scope });

        activePeriodType = $stateParams.periodType;
        $q.when(modalPromise).then(function (modalEl) {
            modalEl.modal('show');
        });
    }

    var updateExpence = function (expence, hide) {
        if (JSON.stringify(masterExpence) !== JSON.stringify(expence)) {
            var promise;
            if (masterExpence.Category != expence.Category) {
                promise =
                    getCategoryAsync(expence.Category)
                        .then(function (category) {
                            expence.CategoryId = category.Id;
                            return expence;
                        });
            } else {
                promise = $timeout(function () {
                    return expence;
                }, 0);
            }

            promise
                .then(createOrUpdateExpenceAsync)
                .then(function (data) {
                    reloadExpences();
                    hide();
                }, function (reason) {
                    alert('An error occured during expence update. Try again later.');
                });
        } else {
            hide();
        }
    }

    var closeEditDialog = function (hide) {
        hide();
        $state.go('.', { periodType: activePeriodType });
    }
    init();
}
