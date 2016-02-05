var ParameterViewModel = function(data) {
    var self = this;

    self.name = ko.observable(data.Name);
    self.description = ko.observable(data.Description);
    self.value = ko.observable(data.Value);

    self.resetValues = function() {
        self.value(null);
    };
};