using ConvertJsonToXMLApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace ConvertJsonToXMLApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConvertToXMLController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    public ConvertToXMLController(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }
    //1- this senario will done just put json objet in jsonfile.json and generated automatically  

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/xml")]
    public IActionResult ConvertToXML()
    {

        string filePathfromJsonFile = _configuration["Jsonfile"];
        string json = System.IO.File.ReadAllText(filePathfromJsonFile);
        string xml2 = Utilities.ConvertJsonToXml(json);
        try
        {
            var relativeFilePath = _configuration["FilePath"];
            var filePath = Path.Combine(_env.ContentRootPath, relativeFilePath);
            System.IO.File.WriteAllText(filePath, xml2);

        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
        return Ok(xml2);
    }
    //2- if we need to do it when send json object from body  
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/xml")]
    public IActionResult ConvertToXML([FromBody] DsClaims dsClaims)
    {

        var xml = SerializeToXml(dsClaims);
        var relativeFilePath = _configuration["FilePath"];
        try
        {
            var filePath = Path.Combine(_env.ContentRootPath, relativeFilePath);
            System.IO.File.WriteAllText(filePath, xml);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
        return Ok("Succeded");
    }
    public string SerializeToXml<T>(T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
        }
    }
}