﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notifyHub").build();
connection.on("notify",
    function (name) {
        $.notify.addStyle('alert-danger',
            {
                html:
                    "<div>" +
                        "<div class='alert alert-danger alert-dismissible' role='alert'>" +
                             "<span data-notify-text/>" +
                        "</div>" +
                    "</div>"
            });
        $.notify("The value of this sensor " + name.toUpperCase() + " is out of acceptable range!",
            {
                autoHideDelay: 35000,
                position: 'left, bottom',
                style: 'alert-danger'
            });
    });

connection.on("offline",
    function (message) {
        $.notify.addStyle('alert-danger',
            {
                html:
                    "<div>" +
                    "<div class='alert alert-danger alert-dismissible' role='alert'>" +
                    "<span data-notify-text/>" +
                    "</div>" +
                    "</div>"
            });
        $.notify(message,
            {
                autoHideDelay: 35000,
                globalPosition: 'middle',
                style: 'alert-danger'
            });
    });

connection.start().catch(function (err) {
    return console.error(err.toString());
});