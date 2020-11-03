using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Threading.Tasks;

namespace SirenController
{
    public class Main : BaseScript
    {
        public static bool SirenSound = false;
        public Main()
        {
            Debug.WriteLine("Abel Gaming Siren Controller Loaded");
            Tick += OnTick;
        }

        private static void SirenStatus()
        {
            if (!SirenSound)
            {
                SirenSound = true;
            }
            else
            {
                SirenSound = false;
            }
        }

        private static async Task OnTick()
        {
            //DISABLE RADIO CONTROLS
            API.SetUserRadioControlEnabled(false);

            //DISABLE CINEMATIC CAMERA
            API.DisableControlAction(0, 80, true);

            if (API.IsControlJustPressed(0, 57)) //B on Controller
            {
                API.BlipSiren(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false));
            }

            if (API.IsControlJustPressed(0, 85)) //D PAD LEFT
            {
                if (!API.IsVehicleSirenOn(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false)))
                {
                    Game.Player.Character.CurrentVehicle.IsSirenActive = true;
                }
                else
                {
                    Game.Player.Character.CurrentVehicle.IsSirenActive = false;
                }
            }

            if (API.IsControlJustPressed(0, 19)) //D PAD DOWN
            {
                if (!SirenSound)
                {
                    SirenSound = true;
                }
                else
                {
                    SirenSound = false;
                }
            }

            if (API.IsPedInAnyPoliceVehicle(API.GetPlayerPed(-1)))
            {
                if (SirenSound)
                {
                    API.SetDisableVehicleSirenSound(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false), false);
                }
                else
                {
                    API.SetDisableVehicleSirenSound(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false), true);
                }
            }
        }
    }
}
