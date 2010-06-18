﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoTest.Core.Messaging;

namespace AutoTest.Core.Presenters
{
    class InformationFeedbackPresenter : IInformationFeedbackPresenter
    {
        private IMessageBus _bus;
        private IInformationFeedbackView _view;

        public IInformationFeedbackView View
        {
            get { return _view; }
            set
            {
                _view = value;
                _bus.OnInformationMessage += new EventHandler<InformationMessageEventArgs>(_bus_OnInformationMessage);
            }
        }

        public InformationFeedbackPresenter(IMessageBus bus)
        {
            _bus = bus;
        }

        void _bus_OnInformationMessage(object sender, InformationMessageEventArgs e)
        {
            _view.RecievingInformationMessage(e.Message);
        }
    }
}