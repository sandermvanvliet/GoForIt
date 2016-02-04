var ListFlowsViewModel = function(listFlowsUrl) {
    var self = this;

    self.listFlowsUrl = listFlowsUrl;

    self.flows = ko.observableArray([]);

    self.load = function() {
        $.getJSON(self.listFlowsUrl)
            .done(function(data) {
                var flows = Array();
                ko.utils.arrayForEach(data, function(item) {
                    flows.push(new FlowViewModel(item));
                });
                self.flows(flows);
            });
    };
};