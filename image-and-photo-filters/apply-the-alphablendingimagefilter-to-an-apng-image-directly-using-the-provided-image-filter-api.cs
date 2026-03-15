using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source APNG image
        string inputPath = "input.apng";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image is an APNG
            if (image is ApngImage apngImage)
            {
                // Define a rectangle covering the whole image
                var rect = new Rectangle(0, 0, apngImage.Width, apngImage.Height);

                // AlphaBlendingImageFilter is not part of the supported filter options.
                // Throwing NotSupportedException to indicate the operation cannot be performed.
                throw new NotSupportedException("AlphaBlendingImageFilter is not supported in Aspose.Imaging .NET.");

                // If the filter were supported, the usage would resemble:
                // apngImage.Filter(rect, new AlphaBlendingImageFilter(...));
                // apngImage.Save();
            }
            else
            {
                Console.WriteLine("The loaded image is not an APNG image.");
            }
        }
    }
}