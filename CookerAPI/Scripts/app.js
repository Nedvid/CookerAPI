var ViewModel = function () {
    var self = this;
    self.recipes = ko.observableArray();
    self.error = ko.observable();

    var booksUri = '/api/recipes/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllRecipes() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.recipes(data);
        });
    }

    // Fetch the initial data.
    getAllRecipes();
};

ko.applyBindings(new ViewModel());