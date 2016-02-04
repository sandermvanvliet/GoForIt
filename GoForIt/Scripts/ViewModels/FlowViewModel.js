var FlowViewModel = function(data) {
    var self = this;

    self.eventName = ko.observable(data.EventName);
    self.actionName = ko.observable(data.ActionName);
};