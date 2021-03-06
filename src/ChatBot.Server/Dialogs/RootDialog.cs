﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatBot.Server.Services.AnalyticsService;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace ChatBot.Server.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            
            await context.PostAsync(activity.Text);
            context.Wait(MessageReceivedAsync);
        }
    }
}