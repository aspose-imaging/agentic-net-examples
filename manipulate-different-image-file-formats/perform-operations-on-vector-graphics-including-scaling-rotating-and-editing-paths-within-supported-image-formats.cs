using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;          // Namespace for DjvuImage
using Aspose.Imaging.ImageOptions;             // Required for save options if needed

class Program
{
    static void Main()
    {
        // Load a DjVu document from a file stream using the provided LoadDocument method
        using (FileStream inputStream = new FileStream("input.djvu", FileMode.Open, FileAccess.Read))
        {
            // The static LoadDocument method returns a DjvuImage instance
            DjvuImage djvu = DjvuImage.LoadDocument(inputStream);

            // -------------------- Scaling --------------------
            // Example: double the size of the image (200% scaling)
            int scaledWidth  = djvu.Width  * 2;
            int scaledHeight = djvu.Height * 2;
            djvu.Resize(scaledWidth, scaledHeight);   // Uses the Resize method from the API

            // -------------------- Rotating --------------------
            // Rotate the image 45 degrees around its center
            djvu.Rotate(45f);                         // Uses the Rotate method from the API

            // -------------------- Saving --------------------
            // Save the transformed image back to disk using the provided Save(string) overload
            djvu.Save("output.djvu");
        }
    }
}