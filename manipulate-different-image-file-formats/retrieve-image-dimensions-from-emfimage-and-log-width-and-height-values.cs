// HOW-TO: Get EMF Image Dimensions in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfImage emf = image as EmfImage;
                if (emf == null)
                {
                    Console.Error.WriteLine("The file is not a valid EMF image.");
                    return;
                }

                int width = emf.Width;
                int height = emf.Height;

                Console.WriteLine($"Width: {width}");
                Console.WriteLine($"Height: {height}");

                File.WriteAllText(outputPath, $"Width: {width}{Environment.NewLine}Height: {height}");
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
 * 1. When you need to validate that an uploaded EMF file meets specific size requirements before processing it further.
 * 2. When generating a report that lists the width and height of each EMF graphic in a batch of design assets.
 * 3. When converting EMF drawings to other formats and you must preserve aspect ratio based on the original dimensions.
 * 4. When logging image metadata for auditing purposes in a C# application that handles vector graphics.
 * 5. When dynamically resizing UI components based on the dimensions of an EMF logo or icon at runtime.
 */
