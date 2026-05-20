using Xabbo.Messages;

namespace Xabbo.Core;

/// <inheritdoc cref="IChatSettings"/>.
public class ChatSettings : IChatSettings, IParserComposer<ChatSettings>
{
    public int TextSize { get; set; }
    public bool Unknown1 { get; set; }

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
