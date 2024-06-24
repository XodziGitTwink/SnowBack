using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DRoomModel : DRoom
{
    public string FullInfo => $"{RoomName} ({Id})";
}
