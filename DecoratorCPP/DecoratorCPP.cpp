#include <iostream>


void printDecorator()
{
    std::cout << "Message: ";
}

void print(const std::string& message, void(*decorator)() = nullptr)
{
    if (decorator != nullptr)
    {
        decorator();
    }
    // ...
    std::cout << message;
}



int main(int argc, char* argv[])
{
    print("Hello C++");
    
    return 0;
}
