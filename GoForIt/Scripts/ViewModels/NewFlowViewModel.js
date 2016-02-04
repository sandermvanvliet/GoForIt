var NewFlowViewModel = function (getEventsUrl, getActionsUrl) {
    var self = this;

    self.getEventsUrl = getEventsUrl;
    self.getActionsUrl = getActionsUrl;

    self.events = ko.observableArray([]);
    self.actions = ko.observableArray([]);
    self.selectedAction = ko.observable();
    self.selectedEvent = ko.observable();

    self.load = function() {
        $.getJSON(self.getEventsUrl)
            .done(function (data) {
                var events = Array();
                ko.utils.arrayForEach(data, function (item) {
                    events.push(new EventViewModel(item));
                });

                self.events(events);
            });
        $.getJSON(self.getActionsUrl)
            .done(function (data) {
                var actions = Array();
                ko.utils.arrayForEach(data, function (item) {
                    actions.push(new EventViewModel(item));
                });

                self.actions(actions);
            });
    };

    self.handleEventClick = function(item) {
        if (self.selectedEvent() !== null && self.selectedEvent() !== undefined) {
            self.selectedEvent().isSelected(false);
        }
        item.isSelected(true);
        self.selectedEvent(item);
    }
};