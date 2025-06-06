namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Cabinet
// Armoire
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct Cabinet {
    [FieldOffset(0x00)] public CabinetState State;
    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray132<byte> _unlockedItems;

    /// <summary>
    /// Check if an item is stored in the player's armoire.
    /// </summary>
    /// <param name="cabinetItemId">The armoire item entry ID to check against. This is not an item ID but a specific ID
    /// from the Cabinet table.</param>
    /// <returns>Returns true if the armoire contains the specified item.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0F 85 DB")]
    public partial bool IsItemInCabinet(int cabinetItemId);

    /// <summary>
    /// Check if the armoire is reporting as "loaded" from the server.
    /// </summary>
    /// <remarks>
    /// The armoire will only load when requested (so, when a player goes to an inn room and chooses to add/remove an
    /// item or performs certain glamour operations). As such, before any check can take place, a developer must first
    /// validate that the armoire is loaded. Generally, this will be when State == CabinetState.Loaded
    /// </remarks>
    /// <returns>Returns true if the armoire has been retrieved.</returns>
    public bool IsCabinetLoaded()
        => this.State is CabinetState.Loaded;

    /// <summary> Represents the loaded state of Cabinet </summary>
    public enum CabinetState : int {
        Invalid = 0, // Cabinet is initialized at this state
        Requested = 1, // This state is set between the client request and receiving the data from the server
        Loaded = 2, // Set upon data being received
    }
}
