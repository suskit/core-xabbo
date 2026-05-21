namespace Xabbo.Core;

/// <summary>
/// Defines chat related settings for a room.
/// </summary>
public interface IChatSettings
{
    /// <summary>
    /// Specifies the chat flood protection level.
    /// </summary>
    ChatFloodProtection FloodProtection { get; }
}
