var EventLogViewModel = function() {
    var self = this;

    self.events = ko.observableArray([]);
    self.actions = ko.observableArray([]);
}