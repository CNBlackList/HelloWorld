using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.Interfaces;
using ReimuAPI.ReimuBase.TgData;

namespace HelloWorld
{
    class CommandListener : ICommandReceiver
    {
        public CallbackMessage OnGroupCommandReceive(TgMessage RawMessage, string JsonMessage, string Command)
        {
            if (SharedCommands(RawMessage, JsonMessage, Command)) return new CallbackMessage();
            return new CallbackMessage();
        }

        public CallbackMessage OnPrivateCommandReceive(TgMessage RawMessage, string JsonMessage, string Command)
        {
            if (SharedCommands(RawMessage, JsonMessage, Command)) return new CallbackMessage();
            return new CallbackMessage();
        }

        public CallbackMessage OnSupergroupCommandReceive(TgMessage RawMessage, string JsonMessage, string Command)
        {
            if (SharedCommands(RawMessage, JsonMessage, Command)) return new CallbackMessage();
            return new CallbackMessage();
        }

        private bool SharedCommands(TgMessage RawMessage, string JsonMessage, string Command)
        {
            switch (Command)
            {
                case "/getid":
                    string info = "Send from:\n" + RawMessage.GetSendUser().GetUserTextInfo();
                    if (RawMessage.GetForwardedFromUser() != null)
                    {
                        info += "\n\nForwarded from (User):\n" + RawMessage.GetForwardedFromUser().GetUserTextInfo();
                    }
                    if (RawMessage.GetForwardedFromChat() != null)
                    {
                        info += "\n\nForwarded from (Channel):\n" + RawMessage.GetForwardedFromChat().GetChatTextInfo();
                    }
                    if (RawMessage.GetReplyMessage() != null)
                    {
                        info += "\n\nReply to: \n" + RawMessage.GetReplyMessage().GetSendUser().GetUserTextInfo();
                    }
                    TgApi.getDefaultApiConnection().sendMessage(RawMessage.GetMessageChatInfo().id, info, RawMessage.message_id);
                    return true;
                case "/help":
                    TgApi.getDefaultApiConnection().sendMessage(
                        RawMessage.GetMessageChatInfo().id,
                        RAPI.getHelpContent(RawMessage),
                        RawMessage.message_id
                        );
                    return true;
                default:
                    break;
            }
            return false;
        }
    }
}
