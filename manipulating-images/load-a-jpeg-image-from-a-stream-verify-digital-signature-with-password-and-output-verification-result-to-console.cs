using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path safety rules
        string inputPath = "input.jpg";
        string outputPath = "output\\result.txt";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load JPEG image from a file stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(stream))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Verify digital signature with password
                string password = "myPassword";
                bool isSigned = rasterImage.IsDigitalSigned(password);

                // Output verification result
                Console.WriteLine($"Digital signature verification: {(isSigned ? "Signed" : "Not signed")}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}