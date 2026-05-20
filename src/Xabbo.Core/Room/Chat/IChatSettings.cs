namespace Xabbo.Core;

/// <summary>
/// Defines chat related settings for a room.
/// </summary>
public interface IChatSettings
{
    /// <summary>
    /// The chat text size.
    /// </summary>
    int TextSize { get; }

    // unknown
    bool Unknown1 { get; }
}
