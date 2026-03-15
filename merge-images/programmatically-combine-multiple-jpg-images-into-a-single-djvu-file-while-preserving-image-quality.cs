using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Folder containing the source JPG images
        string inputFolder = "input_images";
        // Destination DjVu file
        string outputPath = "output.djvu";

        // Retrieve all JPG files from the input folder
        string[] jpgFiles = Directory.GetFiles(inputFolder, "*.jpg");

        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the specified folder.");
            return;
        }

        // Create a multipage image from the JPG files
        using (Image djvuImage = Image.Create(jpgFiles))
        {
            // Save the multipage image as a DjVu document
            djvuImage.Save(outputPath);
        }

        Console.WriteLine($"DjVu file created successfully at: {outputPath}");
    }
}