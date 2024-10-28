






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
                productNumberDictionary[counter++] = eachProduct;
            }
    }
//  public Product(string name, decimal price, int productTypeId)
    // {
    //     Name = name;
    //     Price = price;
    //     ProductTypeId = productTypeId;
    // }
}


Product findProductBasedOffEnteredNumber(){
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Enter the number of the product you want to delete,");
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


void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
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

Product foundProduct = findProductBasedOffEnteredNumber();

    // Now you can safely remove the product
    if (foundProduct != null)
    {
        products.Remove(foundProduct);
        Console.WriteLine("Product removed successfully.");
    }
    else
    {
        Console.WriteLine("No product found to remove.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string ourProductName;
    int ourProductPrice;
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
    string input = Console.ReadLine().Trim().ToLower();
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
ProductType = ourProductType
};
products.Add(ourNewProduct);
Console.WriteLine(@$"new product with {ourProductName} name and {ourProductPrice} price and {ourProductType} type was added ");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
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
    
    string nameToUpdate;
    int priceToUpdate;
    ProductType productTypeToUpdate = null;



Console.WriteLine("If you would like to update the name, press 1. If not, press 2.");

int decisionToUpdateName;
while (true)
{
    // Get initial decision to update the name
    if (!int.TryParse(Console.ReadLine(), out decisionToUpdateName) || decisionToUpdateName < 1 || decisionToUpdateName > 2)
    {
        Console.WriteLine("Please choose either 1 or 2 to make a decision on updating the name.");
    }
    else if (decisionToUpdateName == 2)
    {
        // User decided not to update the name
        Console.WriteLine("You have chosen not to update the product name.");
        return; // Exit from the method if user cancels
    }
    else
    {
        // Proceed with updating the name
        Console.WriteLine("You have chosen to update the name of this product.");
        break;
    }
}

while(true){
    Console.WriteLine("Please enter the new name you want for the product to update with.");
    string input = Console.ReadLine().Trim();
     if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Please enter an actual valid string for the new name. Press 2 to cancel.");
    }
    else {
        Console.WriteLine(@$"you have chosen to update the name of the {productToUpdate.Name} to {input}. If you want to undo this press 2 right now");
        if(int.TryParse(Console.ReadLine(), out decisionToUpdateName) && decisionToUpdateName == 2){
            Console.WriteLine("you have chosen to chancel the decision to update hte product name");
            break;
            //return; if you did this then the entire method here of updating would stop running. This allows you by doing break to try ot update other stuff like price IMPORTANT
        } else {
         nameToUpdate = input;
         break;
        }
    }
}
    // Console.WriteLine(@$"if you would like to update the name press 1. If not press 2");
    // int decisionToUpdateName;
    // while(true){
    // if(!int.TryParse(Console.ReadLine(), out decisionToUpdateName) || decisionToUpdateName < 1 || decisionToUpdateName > 2){
    //     Console.WriteLine("please choose either 1 or 2 to make a decision on updating the name");
    // } else {
    //     break;
    // }
    // }
    // if(decisionToUpdateName == 1){
    //     Console.WriteLine(@"Please enter the new name you want for the product to update with");
    //     while(true){
    //         string input = Console.ReadLine().Trim(); // Read input and trim whitespace
    // if (!string.IsNullOrEmpty(input)){
    //     Console.WriteLine(@"Please enter an actual valid string for the new name you want to update the product to. Press 2 to cancel the decision to update the name");
    //     if(int.TryParse(Console.ReadLine(), out decisionToUpdateName) && decisionToUpdateName == 2){
    //         Console.WriteLine("you have chosen to cancel trying to update the name of the product");
    //         break;
    //     }

    // } else {
    //     nameToUpdate = input;
    //     Console.WriteLine(@$"you have chosen to update the name of the product to ${input}. If you want to reverse this decision do so now by pressing 2");
    //       if(int.TryParse(Console.ReadLine(), out decisionToUpdateName) && decisionToUpdateName == 2){
    //         Console.WriteLine("you have chosen to cancel trying to update the name of the product");
    //         break;

    // }
    //     }
    // }
    // }
    






    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }