

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>();

Dictionary<int, Product> productNumberDictionary = new Dictionary<int, Product>();

// Create instances of Product with associated ProductTypeIds
Product product1 = new Product("Wizard Robe", 49.99m, 1);
Product product2 = new Product("Healing Potion", 19.99m, 2);
Product product3 = new Product("Invisibility Cloak", 199.99m, 3);
Product product4 = new Product("Magic Wand", 79.99m, 3);
Product product5 = new Product("Flying Broom", 249.99m, 3);
Product product6 = new Product("Brass Lamp", 59.99m, 4);
Product product7 = new Product("Poetry Book", 12.99m, 5);

// Add products to the list
products.Add(product1);
products.Add(product2);
products.Add(product3);
products.Add(product4);
products.Add(product5);
products.Add(product6);
products.Add(product7);
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>();

// Create instances of ProductType
ProductType apparel = new ProductType(1, "Apparel");
ProductType potions = new ProductType(2, "Potions");
ProductType enchantedObjects = new ProductType(3, "Enchanted Objects");
ProductType brass = new ProductType(4, "Brass");
ProductType poem = new ProductType(5, "Poem");

// Add product types to the list
productTypes.Add(apparel);
productTypes.Add(potions);
productTypes.Add(enchantedObjects);
productTypes.Add(brass);
productTypes.Add(poem);
//put your greeting here

// Associate product types with products

Product getProductFromList(string productName){

    Product ourProduct = products.FirstOrDefault(p => p.Name.ToLower() == productName.ToLower());

    if(ourProduct == null){
        Console.WriteLine("no product found");
        throw new KeyNotFoundException();
    }
    return ourProduct;
}

ProductType getProductTypeForProduct(Product ourProduct){

    return productTypes.Find(productType => productType.Id == ourProduct.ProductTypeId);

}
//{
//     product.ProductType = productTypes.Find(pt => pt.Id == product.ProductTypeId);
// }

 Console.WriteLine("Welcome to the Product Management Application!");

//implement your loop here

        void clearFunction()
        {
            Console.Clear(); // clear console before showing menu
            Console.WriteLine(@"Choose an option:
    1. Press 1 to display all products.
    2. Press 2 to delete all products.
    3. Press 3 to add a product.
    4. Press 4 to update a product.
    5. Press 5 to exit the application
    ");
        }

        while (true)
        {
            clearFunction();

            string inputChoice = Console.ReadLine().Trim();
            int inputChoiceValue = 0;

            if (!int.TryParse(inputChoice, out inputChoiceValue))
            {
                Console.WriteLine("Please enter valid input choice");
            }
            else if (inputChoiceValue < 1 || inputChoiceValue > 5)
            {
                Console.WriteLine("Please enter value between 1-5");
            }

            else
            {
                if (inputChoiceValue == 1)
                {
                    DisplayAllProducts(products, productTypes);
                }
                else if (inputChoiceValue == 2)
                {
                    DeleteProduct(products, productTypes);
                }
                else if (inputChoiceValue == 3)
                {
                    AddProduct(products, productTypes);
                }
                else if (inputChoiceValue == 4)
                {
                    UpdateProduct(products, productTypes);
                }
                else if (inputChoiceValue == 5)
                {
                    Console.WriteLine("You are leaving the program");
                    break;
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();  // Wait for user to press a key before clearing the console
        }

void DisplayMenu()
{
   clearFunction();
}

void DisplayAllProductTypes(List<ProductType> productTypes)
{
    Console.WriteLine("Available Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int counter = 1;
    foreach(Product eachProduct in products){
        ProductType ourProductType = getProductTypeForProduct(eachProduct);
           Console.WriteLine(@$"
            {counter}. Product: {eachProduct.Name}, Price: {eachProduct.Price:C}, Type: {ourProductType.Title}");
            if (!productNumberDictionary.ContainsKey(counter)){
                productNumberDictionary[counter] = eachProduct;
            }
            counter++;
    }
//  public Product(string name, decimal price, int productTypeId)
    // {
    //     Name = name;
    //     Price = price;
    //     ProductTypeId = productTypeId;
    // }
}


Product findProductBasedOffEnteredNumber(){
    // DisplayAllProducts(products, productTypes);
    Console.WriteLine("Enter the number of the product you want to find");
    int enteredDigit;
    bool validDigit = false;
    Product foundProduct = null;
while (!validDigit)
{
    if (!int.TryParse(Console.ReadLine().Trim(), out enteredDigit))
    {
        Console.WriteLine("Please enter a valid digit.");
    }else{
        foundProduct = productNumberDictionary.GetValueOrDefault(enteredDigit);

        if (foundProduct != null){
            Console.WriteLine($"Product found: {foundProduct.Name} - ${foundProduct.Price}");
            validDigit = true;  // Exit loop
        } else{
            Console.WriteLine("No product found for the given number.");
        }
    }
}

return foundProduct;
}

//     DisplayAllProducts(products, productTypes);
//     Console.WriteLine("Enter the number of the product you want to delete,");
//     int enteredDigit;
//     bool validDigit = false;
//     Product foundProduct = null;
// while (!validDigit)
// {
//     if (!int.TryParse(Console.ReadLine().Trim(), out enteredDigit))
//     {
//         Console.WriteLine("Please enter a valid digit.");
//     }else{
//         foundProduct = productNumberDictionary.GetValueOrDefault(enteredDigit);

//         if (foundProduct != null){
//             Console.WriteLine($"Product found: {foundProduct.Name} - ${foundProduct.Price}");
//             validDigit = true;  // Exit loop
//         } else{
//             Console.WriteLine("No product found for the given number.");
//         }
//     }
// }
void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    // Log input parameters
    Console.WriteLine("Starting DeleteProduct method...");
    Console.WriteLine($"Number of products passed: {products?.Count ?? 0}");
    Console.WriteLine($"Number of product types passed: {productTypes?.Count ?? 0}");

    try
    {
        Product foundProduct = findProductBasedOffEnteredNumber();

        // Log the found product or lack thereof
        if (foundProduct != null)
        {
            Console.WriteLine($"Product found for deletion: {foundProduct.Name}");
            products.Remove(foundProduct);
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("No product found to remove.");
        }
    }
    catch (Exception ex)
    {
        // Log any unexpected exceptions
        Console.WriteLine($"Exception encountered: {ex.Message}");
        throw; // Re-throw to not hide the exception from the test runner
    }
}


void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string ourProductName;
    int ourProductPrice;
    int ourProductTypeId;
    ProductType ourProductType = null;
    Console.WriteLine("please enter a product name you want for the product to add");
  while (true)
{
    string input = Console.ReadLine().Trim(); // Read input and trim whitespace

    if (!string.IsNullOrEmpty(input))
    {
        ourProductName = input;
        Console.WriteLine($"Product name '{ourProductName}' accepted.");
        break;  // Exit the loop when a valid name is entered
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a non-empty product name.");
    }
}
while(true){
    int value;
    Console.WriteLine("please enter the price you want this product you are adding to be");
    if(!int.TryParse(Console.ReadLine(), out value)){
        Console.WriteLine("please enter a valid integer for the price");
    } else {
        ourProductPrice = value;
        Console.WriteLine($"Product price is now {ourProductPrice}");
        break;
    }
}
DisplayAllProductTypes(productTypes);
Console.WriteLine("Please enter the name of the product type you want this product you are adding to be");

while(true){
      string input = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
    if (input == null)
{
    Console.WriteLine("Received null input. Check test setup.");
    return; // Or handle this case appropriately
}


    if(string.IsNullOrEmpty(input)){
        Console.WriteLine("please enter a valid string name for the product type you want");
    } else {
        try {
        ourProductType = productTypes.FirstOrDefault(productType => productType.Title.ToLower() == input.ToLower());
        if(ourProductType != null){
            Console.WriteLine(@$"You have set the product type to {ourProductType.Title}");
            break;
        } else {
                throw new KeyNotFoundException(@$"The specified product type {input} was not found.");
        }
    } catch (KeyNotFoundException ex){
            Console.WriteLine(ex.Message);
    }
}
}
Product ourNewProduct = new Product{
Name = ourProductName,
Price = ourProductPrice,
ProductTypeId = ourProductType.Id
};
products.Add(ourNewProduct);
Console.WriteLine(@$"new product with {ourProductName} name and {ourProductPrice} price and {ourProductType} type and product type ID of {ourProductType.Id} was added ");

Product doesProductExist =  getProductFromList(ourProductName);

Console.WriteLine(@$"the product we added as we try to retrieve with name {doesProductExist.Name} and price of {doesProductExist.Price} and type {doesProductExist.ProductType}");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("products will display below pick the one you want to update");
    DisplayAllProducts(products, productTypes);
    Product productToUpdate = null;
    while(productToUpdate == null){
         Product foundProduct = findProductBasedOffEnteredNumber();
         if (foundProduct != null)
    {
        productToUpdate = foundProduct;
        Console.WriteLine(@$"{foundProduct.Name} has been found");
        break;
    }
    else
    {
        Console.WriteLine("No product found to try to update please try again");
    }
    }
    
    string nameToUpdate = UpdateProductName(productToUpdate);
    productToUpdate.Name = nameToUpdate;
     decimal priceToUpdate = UpdateProductPrice(productToUpdate.Price);
    productToUpdate.Price = priceToUpdate;
    ProductType productTypeToUpdate = UpdateProductType(productTypes, productToUpdate.ProductTypeId);
    if(productTypeToUpdate != null){
        productToUpdate.ProductTypeId = productTypeToUpdate.Id;
    }

    Console.WriteLine("Product successfully updated!");

}


string UpdateProductName(Product productToUpdate)
{
    Console.WriteLine("If you would like to update the name, press 1. If not, press 2.");

    int decisionToUpdateName;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out decisionToUpdateName) || decisionToUpdateName < 1 || decisionToUpdateName > 2)
        {
            Console.WriteLine("Please choose either 1 or 2.");
        }
        else if (decisionToUpdateName == 2)
        {
            Console.WriteLine("You have chosen not to update the product name.");
            return productToUpdate.Name;
        }
        else
        {
            break;
        }
    }

    while (true)
    {
        Console.WriteLine("Please enter the new name:");
        string input = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid name. Press 2 to cancel.");
        }
        else
        {
            Console.WriteLine(@$"Updating {productToUpdate.Name} to {input}. Press 2 to undo. Press enter to continue");
            if (int.TryParse(Console.ReadLine(), out decisionToUpdateName) && decisionToUpdateName == 2)
            {
                Console.WriteLine("Name update cancelled.");
                return productToUpdate.Name;
            }
            else
            {
                return input;
            }
        }
    }
}

decimal UpdateProductPrice(decimal currentPrice)
{
    Console.WriteLine($"Current price: {currentPrice:C}");
    Console.WriteLine("If you would like to update the price, press 1. If not, press 2.");

    int decision;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out decision) || (decision < 1 || decision > 2))
        {
            Console.WriteLine("Please enter 1 to update the price or 2 to skip.");
        }
        else if (decision == 2)
        {
            Console.WriteLine("You have chosen not to update the price.");
            return currentPrice; // Return the current price if skipped
        }
        else
        {
            break; // Proceed with price update
        }
    }

    while (true)
    {
        Console.WriteLine("Enter the new price:");
        if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
        {
            return price; // Return the new price
        }
        else
        {
            Console.WriteLine("Invalid price. Please enter a valid decimal value.");
        }
    }
}


ProductType UpdateProductType(List<ProductType> productTypes, int currentTypeId)
{
    // Fetch the current product type based on the ID
    ProductType currentType = productTypes.FirstOrDefault(pt => pt.Id == currentTypeId);

    if (currentType == null)
    {
        Console.WriteLine($"Error: No matching product type found for ID {currentTypeId}");
        return null; // Handle null to avoid further issues
    }

    Console.WriteLine($"Current product type: {currentType.Title}");
    Console.WriteLine("If you would like to update the product type, press 1. If not, press 2.");

    int decision;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out decision) || decision < 1 || decision > 2)
        {
            Console.WriteLine("Please enter 1 to update the product type or 2 to skip.");
        }
        else if (decision == 2)
        {
            Console.WriteLine("You have chosen not to update the product type.");
            return currentType; // Return the current type if skipped
        }
        else
        {
            break; // Proceed with type update
        }
    }

    // Display available product types
    Console.WriteLine("Available product types:");
    foreach (var type in productTypes)
    {
        Console.WriteLine(@$"{type.Id}. {type.Title}");
    }

    // Prompt user to enter the new product type name
    while (true)
    {
        Console.WriteLine("Enter the name of the new product type:");
        string input = Console.ReadLine().Trim().ToLower();

        ProductType matchingType = productTypes.FirstOrDefault(pt => pt.Title.ToLower() == input);
        if (matchingType != null)
        {
            return matchingType; // Return the selected type
        }
        else
        {
            Console.WriteLine("Invalid product type name. Please try again.");
        }
    }
}



// don't move or change this!
public partial class Program { }