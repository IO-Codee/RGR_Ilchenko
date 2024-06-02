class Handler: # Abstract handler
    def __init__(self):
        self._next = None

    def set_next(self, handler):
        self._next = handler
        return handler

    def handle(self, request):
        if self._next:
            return self._next.handle(request)

        return None

class ConcreteHandler1(Handler): # Inherits from the abstract handler
    def handle(self, request):
        if request == "request1":
            return f"ConcreteHandler1: Handled {request}"
        else:
            return super().handle(request)

class ConcreteHandler2(Handler): # Inherits from the abstract handler
    def handle(self, request):
        if request == "request2":
            return f"ConcreteHandler2: Handled {request}"
        else:
            return super().handle(request)

def client_code(handler):
    for request in ["request1", "request2", "request3"]:
        print(f"\nClient: Who wants to handle {request}?")
        result = handler.handle(request)
        if result:
            print(f"  {result}")
        else:
            print(f"  {request} was not handled.")

if __name__ == "__main__":
    handler1 = ConcreteHandler1()
    handler2 = ConcreteHandler2()

    handler1.set_next(handler2)

    # Send requests to the chain
    print("Chain: Handler1 > Handler2")
    client_code(handler1)

    print("\n")
    print("Subchain: Handler2")
    client_code(handler2)
