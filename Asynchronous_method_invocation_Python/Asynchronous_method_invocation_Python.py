import asyncio

async def async_function():
    print('Async function started')
    await asyncio.sleep(2)  # simulate IO-bound operation with asyncio.sleep
    print('Async function finished')
    return 42

def main():
    print('Main function started')

    # Get a reference to the event loop
    loop = asyncio.get_event_loop()

    # Schedule the execution of the coroutine and return a Future object
    future = loop.create_task(async_function())

    # Run the event loop until the Future is done
    loop.run_until_complete(future)

    # Get the result from the Future
    result = future.result()
    print(f'Result: {result}')

    print('Main function finished')

if __name__ == '__main__':
    main()
