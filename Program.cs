using Newtonsoft.Json; 

var currentDirectory = Directory.GetCurrentDirectory(); 
var storesDirectory = Path.Combine(currentDirectory, "stores"); 

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir"); 
Directory.CreateDirectory(salesTotalDir); 

var salesFiles = FindFiles(storesDirectory); 

var salesTotal = CalculateSalesTotal(salesFiles); 

File.AppensAllText(Path.Combine(salesTotalDire, "totals.txt"), $"{salesTotal}{Environment.NewLine}")
IEnumerable<string> FindFiles(string folerName)
{
  List<string> salesFiles = new List<string>();
  var founFiles = Directory.EnumerableFiles(folderName, "*", SearchOption.AllDirectories);

  foreach(var file in foundFiles) {
    var extension = Path.GetExtension(file); 
    if(extension == ".json"){
      salesFiles.Add(file); 
    }
    return salesFiles; 
  }
}

double CalculateSalestotal(IEnumerable<sting> salesFiles){
  double salesTotal = 0; 
  //loop over each file path in salesFiles
  foreach(var file in salesFiles)
  {
    //Read the contents of the file
    string salesJson = File.ReadAllText(file); 

    //Parse the contents as JSON
    SalesData? data = JsonConvert.DeserializeObjecct<SalesData?>(salesJson);

    //Add the amount found in the Total field to the salesTotal variable
    salesTotal += data?.Total ?? 0; 
  }
}
