using Xabbo.Messages;

namespace Xabbo.Core;

/// <inheritdoc cref="IChatSettings"/>.
public class ChatSettings : IChatSettings, IParserComposer<ChatSettings>
{
    public int TextSize { get; set; }
    public bool Unknown1 { get; set; }

    // legacy fields kept for UI/extension compatibility on the core-xabbo branch;
    // habbo dropped these from the wire so they always carry their default value.
    public ChatFlow Flow { get; set; } = ChatFlow.LineByLine;
    public ChatBubbleWidth BubbleWidth { get; set; } = ChatBubbleWidth.Normal;
    public ChatScrollSpeed ScrollSpeed { get; set; } = ChatScrollSpeed.Normal;
    public int TalkHearingDistance { get; set; } = 14;
    public ChatFloodProtection FloodProtection { get; set; } = ChatFloodProtection.Standard;

    public ChatSettings()
    {
        TextSize = 1;
    }

    internal ChatSettings(in PacketReader p)
    {
        TextSize = p.ReadInt();
        Unknown1 = p.ReadBool();
    }

    void IComposer.Compose(in PacketWriter p)
    {
        p.WriteInt(TextSize);
        p.WriteBool(Unknown1);
    }

    static ChatSettings IParser<ChatSettings>.Parse(in PacketReader p) => new(in p);
}
