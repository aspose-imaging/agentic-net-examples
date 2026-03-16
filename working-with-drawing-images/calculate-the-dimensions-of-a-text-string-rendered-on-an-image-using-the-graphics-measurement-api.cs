using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Create an in‑memory PNG image to obtain a Graphics object.
        using (MemoryStream ms = new MemoryStream())
        {
            // Set up PNG options with a stream source.
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(ms);

            // Create a blank image (width: 500 px, height: 200 px).
            using (Image image = Image.Create(pngOptions, 500, 200))
            {
                // Initialize Graphics for the image.
                Graphics graphics = new Graphics(image);

                // Define the text, font and layout area.
                string text = "Hello Aspose!";
                Font font = new Font("Arial", 24);
                SizeF layoutArea = new SizeF(500, 200);
                StringFormat format = new StringFormat();

                // Measure the string.
                SizeF measuredSize = graphics.MeasureString(text, font, layoutArea, format);

                // Output the measured dimensions.
                Console.WriteLine($"Measured Width: {measuredSize.Width}");
                Console.WriteLine($"Measured Height: {measuredSize.Height}");

                // Save the image (optional, just to finalize the stream).
                image.Save();
            }
        }
    }
}