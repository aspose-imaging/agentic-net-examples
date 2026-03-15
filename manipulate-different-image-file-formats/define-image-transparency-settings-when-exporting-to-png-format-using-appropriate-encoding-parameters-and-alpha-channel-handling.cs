using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Drawing;

class Program
{
    static void Main()
    {
        // --------------------------------------------------------------------
        // Example 1: Preserve existing alpha channel when exporting to PNG
        // --------------------------------------------------------------------
        string sourcePath = "input.png";               // source image (may already contain transparency)
        string outputPath = "output_transparent.png";   // destination PNG file

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Configure PNG options to keep per‑pixel alpha
            PngOptions pngOptions = new PngOptions
            {
                // Truecolor with Alpha stores an 8‑bit alpha channel for each pixel
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8,                     // 8 bits per channel (standard)
                CompressionLevel = 9,             // maximum compression (0‑9)
                FilterType = PngFilterType.Adaptive, // best overall compression
                Progressive = true                // enable progressive loading (optional)
            };

            // Save the image using the defined transparency settings
            image.Save(outputPath, pngOptions);
        }

        // --------------------------------------------------------------------
        // Example 2: Create a PNG without native alpha and define a transparent color key
        // --------------------------------------------------------------------
        string createdPath = "created_transparent.png";

        // Set up creation options – Truecolor (no alpha) + transparent color key
        PngOptions createOptions = new PngOptions
        {
            ColorType = PngColorType.Truecolor,   // no alpha channel
            BitDepth = 8,
            CompressionLevel = 9,
            FilterType = PngFilterType.Sub,
            Progressive = true,
            // Define the file where the image will be created
            Source = new FileCreateSource(createdPath, false)
        };

        // Create a new 200×200 PNG image with the above options
        using (Image img = Image.Create(createOptions, 200, 200))
        {
            // Cast to PngImage to access transparency‑related properties
            PngImage pngImg = (PngImage)img;

            // Define the color that should be treated as fully transparent
            pngImg.TransparentColor = Color.Red;
            pngImg.HasTransparentColor = true;

            // Optional: set a background color that will appear where transparency is applied
            pngImg.BackgroundColor = Color.Green;
            pngImg.HasBackgroundColor = true;

            // Draw on the image
            Graphics graphics = new Graphics(pngImg);
            graphics.Clear(Color.White); // fill whole canvas with white

            // Draw a red rectangle – this area will become transparent because of the color key
            graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 100, 100));

            // Save the image (options are already attached via the Source property)
            pngImg.Save();
        }
    }
}