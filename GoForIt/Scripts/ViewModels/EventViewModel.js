var EventViewModel = function(data, applicationName) {
    var self = this;
    console.log("my application name is " + applicationName);
    self.name = ko.observable(data.Name);
    self.isSelected = ko.observable(false);
    self.parameters = ko.observableArray([]);
    self.applicationName = ko.observable(applicationName);

    var params = Array();

    ko.utils.arrayForEach(
        data.Parameters,
        function(item) {
            params.push(new ParameterViewModel(item));
        });

    self.parameters(params);

    self.resetValues = function() {
        ko.utils.arrayForEach(
            data.Parameters,
            function (item) {
                if (item.resetValues !== undefined) {
                    item.resetValues();
                }
            });
    };
};