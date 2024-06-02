from abc import ABC, abstractmethod

# The Product abstract class
class Product(ABC):
    @abstractmethod
    def operation(self):
        pass

# Concrete Product classes
class ConcreteProduct1(Product):
    def operation(self):
        return "{Result of the ConcreteProduct1}"

class ConcreteProduct2(Product):
    def operation(self):
        return "{Result of the ConcreteProduct2}"

# The Creator abstract class
class Creator(ABC):
    @abstractmethod
    def factory_method(self):
        pass

    def some_operation(self):
        # Call the factory method to create a Product object.
        product = self.factory_method()
        # Now, use the product.
        return "Creator: The same creator's code has just worked with " + product.operation()

# Concrete Creator classes
class ConcreteCreator1(Creator):
    def factory_method(self):
        return ConcreteProduct1()

class ConcreteCreator2(Creator):
    def factory_method(self):
        return ConcreteProduct2()

# Client code
def client_code(creator: Creator):
    print(f"Client: I'm not aware of the creator's class, but it still works.\n{creator.some_operation()}")

if __name__ == "__main__":
    print("App: Launched with the ConcreteCreator1.")
    client_code(ConcreteCreator1())
    print("\n")

    print("App: Launched with the ConcreteCreator2.")
    client_code(ConcreteCreator2())
