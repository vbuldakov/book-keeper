var newExpenceViewModel = (function () {

    var _initDate = function () {
        var now = new Date();
        var nowStr = now.getDate() + '/' + (now.getMonth() + 1) + '/' + now.getFullYear();
        var $expDate = $('#new-exp-date');
        $expDate.find('input').attr('value', nowStr);
        $expDate.attr('data-date', nowStr);

        $expDate.datepicker();
    }

    // Categories initialization

    var _categories = [];

    var _initCategories = function () {

        $.get("api/categories", _loadCategories);

        $("#new-exp-category").select2({
            query: function (query) {
                var categoriesToShow = _categories;

                if (query.term.length > 0) {
                    var hasTerm = false;
                    categoriesToShow = [];

                    for (var pos = 0; pos < _categories.length; pos++) {
                        if (_categories[pos].text.indexOf(query.term) != -1) {
                            if (_categories[pos].text == termItem.text) {
                                hasTerm = true;
                            }
                            categoriesToShow.push(_categories[pos]);
                        }
                    }

                    if (!hasTerm) {
                        categoriesToShow.unshift({ id: -1, text: query.term });
                    }
                }

                query.callback({ results: categoriesToShow });
            }
        });
    }

    var _loadCategories = function (data) {
        _categories = $.map(data, _mapCategory);
    };

    var _mapCategory = function (item, i) {
        return {
            id: item.Id,
            text: item.Name
        };
    }

    // End categories initialization

    var _init = function () {
        _initDate();
        _initCategories();
    }

    return {
        init : _init
    };
})();

$(document).ready(newExpenceViewModel.init);