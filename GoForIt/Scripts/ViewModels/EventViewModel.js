var EventViewModel = function(data) {
    var self = this;

    self.name = ko.observable(data.Name);
    self.isSelected = ko.observable(false);
    self.parameters = ko.observableArray([]);

    var params = Array();

    ko.utils.arrayForEach(
        data.Parameters,
        function(item) {
            params.push(new ParameterViewModel(item));
        });

    self.parameters(params);
};