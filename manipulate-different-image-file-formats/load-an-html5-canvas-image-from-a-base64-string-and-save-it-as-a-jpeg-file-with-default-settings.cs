using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input_base64.txt";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read the Base64 string from the input file
            string base64String = File.ReadAllText(inputPath);

            // Convert Base64 string to a byte array
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Load the image from the byte array using a memory stream
            using (var memoryStream = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(memoryStream))
                {
                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as JPEG with default settings
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives a base64‑encoded HTML5 Canvas snapshot from a browser and needs to store it as a JPEG file on the server using C# and Aspose.Imaging.
 * 2. When an API endpoint processes user‑uploaded canvas data encoded in base64 and must convert it to a standard image format for further analysis or archiving.
 * 3. When a desktop utility reads a base64 string saved in a text file, loads it as an image, and saves it as a JPEG to integrate with existing image‑processing pipelines.
 * 4. When a background service validates that a base64‑encoded image exists, decodes it, and writes a JPEG version to a network share for reporting purposes.
 * 5. When a developer wants to quickly transform HTML5 Canvas output captured as base64 into a JPEG without manually handling image codecs, leveraging Aspose.Imaging’s Image.Load and Save methods.
 */