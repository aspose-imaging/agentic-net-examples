using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

namespace ImageConversionExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Image image = null;
                try
                {
                    // Load the image
                    image = Image.Load(inputPath);

                    // Save the image in a different format (based on output file extension)
                    image.Save(outputPath);
                }
                catch (ImageLoadException ex)
                {
                    Console.Error.WriteLine($"Error loading image: {ex.Message}");
                }
                catch (ImageSaveException ex)
                {
                    Console.Error.WriteLine($"Error saving image: {ex.Message}");
                }
                finally
                {
                    // Ensure the image is disposed even if an exception occurs
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected exceptions
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}