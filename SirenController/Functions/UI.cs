using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace SirenController.Functions
{
    public class UI : BaseScript
    {
        private static bool Controller = true;
        public UI()
        {
            Tick += OnTick;
            API.RegisterCommand("controller", new Action(EnableController), false);
        }

        private static void EnableController()
        {
            if (!Controller)
            {
                Controller = true;
            }
            else
            {
                Controller = false;
            }
        }

        private static async Task OnTick()
        {
            if (Controller && API.IsPedInAnyPoliceVehicle(API.GetPlayerPed(-1)))
            {
                //Draw Rectangle
                API.DrawRect(0.925f, 0.5f, 0.175f, 0.175f, 0, 0, 0, 150);

                //DRAW TEXT
                API.SetTextScale(0.4f, 0.4f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Siren Controller");
                API.DrawText(0.875f, 0.41f);
                API.EndTextComponent();

                //EMERGENCY LIGHTS
                if (API.IsVehicleSirenOn(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false)))
                {
                    //Draw Lights On Text
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~o~EMERGENCY LIGHTS");
                    API.DrawText(0.84f, 0.435f); //0.025 SPACING
                    API.EndTextComponent();
                }
                else
                {
                    //Draw Lights Off Text
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~c~EMERGENCY LIGHTS");
                    API.DrawText(0.84f, 0.435f);
                    API.EndTextComponent();
                }

                //EMERGENCY SIREN
                if (API.IsVehicleSirenSoundOn(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false)))
                {
                    //Draw Lights On Text
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~o~EMERGENCY SIREN");
                    API.DrawText(0.84f, 0.46f);
                    API.EndTextComponent();
                }
                else
                {
                    //Draw Lights On Text
                    API.SetTextScale(0.4f, 0.4f);
                    API.SetTextFont(0);
                    API.SetTextProportional(true);
                    API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    API.SetTextOutline();
                    API.SetTextEntry("STRING");
                    API.AddTextComponentString("~c~EMERGENCY SIREN");
                    API.DrawText(0.84f, 0.46f);
                    API.EndTextComponent();
                }
            }
        }
    }
}
