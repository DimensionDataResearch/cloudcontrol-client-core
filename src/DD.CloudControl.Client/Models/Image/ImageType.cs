namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    ///     Well-known CloudControl image types.
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        ///     An unknown image type.
        /// </summary>
        /// <remarks>
        ///     Used to detect uninitialised values; do not use directly.
        /// </remarks>
        Unknown = 0,

        /// <summary>
        ///     An OS (vendor-provided) image.
        /// </summary>
        OS = 1,

        /// <summary>
        ///     A custom (customer-provided) image.
        /// </summary>
        Customer = 2
    }
}
