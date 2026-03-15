using System;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Path to the source WebP image
        string inputPath = @"C:\Temp\source.webp";

        // Load the WebP image using the Aspose.Imaging.Image.Load method (lifecycle rule)
        using (Image webpImage = Image.Load(inputPath))
        {
            // Retrieve the default WebP options for the loaded image.
            // GetDefaultOptions returns an object; cast it to WebPOptions.
            WebPOptions webpDefaultOptions = webpImage.GetDefaultOptions(new object[0]) as WebPOptions;

            // If the cast succeeded, enumerate all public properties of WebPOptions.
            if (webpDefaultOptions != null)
            {
                Console.WriteLine("Supported WebP input parameters (default values):");
                PropertyInfo[] properties = typeof(WebPOptions).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in properties)
                {
                    // Retrieve the current value of the property from the default options instance.
                    object value = prop.GetValue(webpDefaultOptions);
                    Console.WriteLine($"{prop.Name} = {value ?? "null"}");
                }
            }
            else
            {
                Console.WriteLine("Unable to obtain WebPOptions from the loaded image.");
            }

            // Prepare GIF save options (conversion target).
            GifOptions gifOptions = new GifOptions
            {
                // Example: set background color to white (optional)
                BackgroundColor = Color.White
            };

            // Save the image as GIF using the Aspose.Imaging.Image.Save method (lifecycle rule)
            string outputPath = @"C:\Temp\converted.gif";
            webpImage.Save(outputPath, gifOptions);
        }
    }
}