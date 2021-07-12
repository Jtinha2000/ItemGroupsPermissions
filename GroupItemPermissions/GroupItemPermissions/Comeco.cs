using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Provider;
using SDG.Framework;
using Rocket.Core;
using SDG.Unturned;
using Rocket.Unturned.Events;
using SDG.NetTransport;
using SDG.SteamworksProvider;
using Rocket.Unturned.Permissions;
using Rocket.API.Collections;
using Rocket.Unturned.Enumerations;
using Rocket.API.Serialisation;

namespace GroupItemPermissions
{
    public class Comeco : RocketPlugin<Configuração>
    {
        public static Comeco Instance { get; private set; }
        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerInventoryAdded += UnturnedPlayerEvents_OnPlayerInventoryAdded;
            UnturnedPlayerEvents.OnPlayerInventoryRemoved += UnturnedPlayerEvents_OnPlayerInventoryRemoved;
            Logger.Log("Plugin - Itempermissions carregado com sucesso! (BY: CommunistDoggu)", ConsoleColor.Green);
        }

        private void UnturnedPlayerEvents_OnPlayerInventoryRemoved(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex, ItemJar P)
        {
            for (int timer = 0; timer < Comeco.Instance.Configuration.Instance.Permissions.Count; timer++)
            {
                if (P.item.id == Comeco.Instance.Configuration.Instance.Permissions[timer].Id)
                {
                    IRocketPlayer jogador = (IRocketPlayer)player;
                    R.Permissions.RemovePlayerFromGroup(Comeco.Instance.Configuration.Instance.Permissions[timer].Permission, player);
                    if (Comeco.Instance.Configuration.Instance.Permissions[timer].HasDropMessage == true)
                    {
                        UnturnedChat.Say(player.CSteamID, Comeco.Instance.Configuration.Instance.Permissions[timer].DropMessage);
                    }
                }
            }
        }

        private void UnturnedPlayerEvents_OnPlayerInventoryAdded(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex, ItemJar P)
        {
            for (int timer = 0; timer < Comeco.Instance.Configuration.Instance.Permissions.Count; timer++)
            {
                if (P.item.id == Comeco.Instance.Configuration.Instance.Permissions[timer].Id)
                {
                    IRocketPlayer jogador = (IRocketPlayer)player;
                    R.Permissions.AddPlayerToGroup(Comeco.Instance.Configuration.Instance.Permissions[timer].Permission, player);
                    if (Comeco.Instance.Configuration.Instance.Permissions[timer].HasGetMessage == true)
                    {
                        UnturnedChat.Say(player, Comeco.Instance.Configuration.Instance.Permissions[timer].GetMessage);
                    }
                }
            }
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerInventoryRemoved -= UnturnedPlayerEvents_OnPlayerInventoryRemoved;
            UnturnedPlayerEvents.OnPlayerInventoryAdded -= UnturnedPlayerEvents_OnPlayerInventoryAdded;
            Logger.Log("Plugin - Itempermissions descarregado com sucesso!", ConsoleColor.Green);
        }
    }
}