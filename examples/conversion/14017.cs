using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Directory containing the source GIF
        string dir = @"c:\temp\";

        // Load the GIF image
        using (Image gifImage = Image.Load(dir + "sample.gif"))
        {
            // Configure WebPOptions – these are the supported input options when converting from GIF to WebP
            var webpOptions = new WebPOptions
            {
                // Determines whether the output WebP is lossless (true) or lossy (false)
                Lossless = false,

                // Quality factor for lossy compression (0‑100). Ignored when Lossless = true
                Quality = 80f,

                // Background color for animated WebP frames (ARGB format)
                AnimBackgroundColor = (uint)Aspose.Imaging.Color.White.ToArgb(),

                // Number of animation loops (0 = infinite). Relevant for animated WebP
                AnimLoopCount = 0,

                // Hint for internal buffer size (in bytes). Optional
                BufferSizeHint = 1024 * 1024,

                // Preserve original metadata (EXIF, XMP, etc.) in the output file
                KeepMetadata = true,

                // Indicates whether the whole frame should be treated as a full frame
                FullFrame = true,

                // Optional color palette for indexed images (null = default)
                Palette = null,

                // Optional progress event handler (null = no progress reporting)
                ProgressEventHandler = null,

                // Optional resolution settings (null = use source resolution)
                ResolutionSettings = null,

                // Source for creating a new image – not required when only saving
                Source = null,

                // Options for rasterizing vector images (null = not applicable for GIF source)
                VectorRasterizationOptions = null,

                // Optional XMP metadata container (null = no XMP data)
                XmpData = null,

                // Multi‑page options to control which frames are exported (null = export all)
                MultiPageOptions = null
            };

            // Save the GIF as a WebP file using the configured options
            gifImage.Save(dir + "converted.webp", webpOptions);
        }
    }
}