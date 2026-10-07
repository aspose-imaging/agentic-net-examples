// HOW-TO: Get Digital Signature Confidence Percentage of a JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string password = "password";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int confidence = image.AnalyzePercentageDigitalSignature(password);
                Console.WriteLine($"Digital signature confidence: {confidence}%");
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
 * 1. When you need to verify the authenticity of a JPEG received from a client by checking its embedded digital signature confidence.
 * 2. When integrating image security checks into a C# application that processes user‑uploaded photos and must ensure they haven't been tampered with.
 * 3. When building a workflow that logs the confidence level of digital signatures for compliance reporting on medical imaging files saved as JPEG.
 * 4. When creating a batch script that scans a folder of JPEGs and outputs each file’s signature confidence to identify potentially forged images.
 * 5. When developing a digital rights management system that validates the trust level of JPEG assets before allowing them to be displayed in a .NET web portal.
 */
