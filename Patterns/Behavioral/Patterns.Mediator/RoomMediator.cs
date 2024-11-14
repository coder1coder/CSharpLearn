using System.Collections.Generic;
using System.Linq;

namespace Patterns.Mediator
{
    public class RoomMediator
    {
        public readonly List<RoomMember> Members = new();
        
        public RoomMember AttachMember(RoomMember roomMember)
        {
            roomMember.SetMediator(this);
            Members.Add(roomMember);
            return roomMember;
        }

        public void Send(string userName, string message)
        {
            Members.FirstOrDefault(x=>x.Name == userName)?.Notify(message);
        }
    }
}