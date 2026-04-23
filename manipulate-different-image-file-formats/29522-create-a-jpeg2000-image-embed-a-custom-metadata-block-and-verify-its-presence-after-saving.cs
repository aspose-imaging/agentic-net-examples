using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create JPEG2000 options with a custom comment (metadata block)
            Jpeg2000Options options = new Jpeg2000Options();
            options.Comments = new string[] { "CustomMetadataBlock" };

            // Create a JPEG2000 image with the specified options
            using (Jpeg2000Image image = new Jpeg2000Image(200, 200, options))
            {
                // Draw a simple red rectangle to have some pixel data
                Graphics graphics = new Graphics(image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, image.Bounds);

                // Save the image
                image.Save(outputPath);
            }

            // Verify the custom metadata block after loading the saved image
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (Jpeg2000Image loadedImage = new Jpeg2000Image(outputPath))
            {
                // Attempt to read the comments (metadata) from the loaded image
                // Note: Jpeg2000Image exposes the Comments property via its metadata
                var comments = loadedImage.Comments;
                if (comments != null && Array.IndexOf(comments, "CustomMetadataBlock") >= 0)
                {
                    Console.WriteLine("Custom metadata block verified.");
                }
                else
                {
                    Console.WriteLine("Custom metadata block not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}