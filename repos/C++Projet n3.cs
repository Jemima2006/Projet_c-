#include <iostream>
using namespace std;
int main() {
    int entier1;
    cout << "saisir le troisieme entier" << endl;
    cin >> entier1;
    if (entier1 < 0)
    {
        cout << "votre nombre est negatif!" << endl;
    }
    else if (entier1 > 0)
    {
        cout << "votre nombre est positif" << endl;
    }
    else
    {
        cout << "zero" << endl;
    }
    return 0;
}