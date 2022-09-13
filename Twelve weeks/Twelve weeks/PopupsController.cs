using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve_weeks
{
    internal class PopupsController
    {
        public async static void ShowAlert(ContentPage page, string title, string text, string buttonText)
        {
            await page.DisplayAlert(title, text, buttonText);
        }

        public async static Task<bool> AskUser(ContentPage page, string title, string text, string confirm, string exit)
        {

            return await page.DisplayAlert(title, text, confirm, exit);
            
        }
    }
}
