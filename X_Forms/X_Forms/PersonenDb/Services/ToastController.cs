using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    public enum ToastDuration
    {
        Long,
        Short
    }

    public static class ToastController
    {
        //vgl. PersonenDbController
        //Globaler Zugriff erfolgt hier über statische Klasse
        public static void ShowToastMessage(string message, ToastDuration duration)
        {
            switch (duration)
            {
                case ToastDuration.Long:
                    toastService.ShowLong(message);
                    break;
                case ToastDuration.Short:
                    toastService.ShowShort(message);
                    break;
                default:
                    break;
            }
        }

        private static IToastService toastService = DependencyService.Get<IToastService>();
    }
}

