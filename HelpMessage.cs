using ReimuAPI.ReimuBase.Interfaces;
using ReimuAPI.ReimuBase.TgData;

namespace HelloWorld
{
    class HelpMessage : IHelpMessage
    {
        public string GetHelpMessage(TgMessage RawMessage, string MessageType)
        {
            return "/help - 获得帮助\n/getid - 获得 ID （可以回复一条消息来获取消息的发送者）";
        }
    }
}
