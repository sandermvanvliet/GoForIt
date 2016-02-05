var ApplicationEventsViewModel = function(data) {
    var self = this;

    self.name = ko.observable(data.Name);
    self.events = ko.observableArray([]);

    var events = Array();
    ko.utils.arrayForEach(
        data.Events,
        function(item) {
            events.push(new EventViewModel(item));
        });

    self.events(events);
};