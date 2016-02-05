var NewFlowViewModel = function (getEventsUrl, getActionsUrl, addFlowUrl) {
    var self = this;

    self.getEventsUrl = getEventsUrl;
    self.getActionsUrl = getActionsUrl;
    self.addFlowUrl = addFlowUrl;

    self.events = ko.observableArray([]);
    self.actions = ko.observableArray([]);
    self.selectedAction = ko.observable();
    self.selectedEvent = ko.observable();

    self.load = function() {
        $.getJSON(self.getEventsUrl)
            .done(function (data) {
                var events = Array();
                ko.utils.arrayForEach(data, function (item) {
                    events.push(new ApplicationEventsViewModel(item));
                });

                self.events(events);
            });
        $.getJSON(self.getActionsUrl)
            .done(function (data) {
                var actions = Array();
                ko.utils.arrayForEach(data, function (item) {
                    actions.push(new ApplicationEventsViewModel(item));
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
    };

    self.handleActionClick = function(item) {
        if (self.selectedAction() !== null && self.selectedAction() !== undefined) {
            self.selectedAction().isSelected(false);
        }
        item.isSelected(true);
        self.selectedAction(item);
    };

    self.saveFlow = function() {
        var data = {
            EventName: self.selectedEvent().name(),
            EventApplication: self.selectedEvent().applicationName(),
            EventParameters: self.selectedEvent().parameters(),
            ActionName: self.selectedAction().name(),
            ActionApplication: self.selectedAction().applicationName(),
            ActionParameters: self.selectedAction().parameters()
        };

        $.post(
            self.addFlowUrl,
            data,
            function(response) {
                if (response.success) {
                    toastr.success("Flow saved successfully", "New flow");
                    if (self.selectedEvent() !== null) {
                        self.selectedEvent().resetValues();
                    }
                    if (self.selectedAction() != null) {
                        self.selectedAction().resetValues();
                    }
                    self.clearSelections();
                } else {
                    toastr.error("Failed to save flow: " + response.errorMessage, "Bugger!");
                }
            },
            "json");
    };

    self.clearSelections = function() {
        if (self.selectedEvent() !== undefined && self.selectedEvent() !== null) {
            self.selectedEvent().isSelected(false);
            self.selectedEvent(null);
        }
        if (self.selectedAction() !== undefined && self.selectedAction() !== null) {
            self.selectedAction().isSelected(false);
            self.selectedAction(null);
        }
    };
};