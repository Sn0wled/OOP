/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

int main() {
    int a = 1, b = 7;
    swap(a, b);
    char x = 7, y = 9;
    swap(x, y);
    double p = 11, q = 13;
    swap(p, q);

    int ar[] = { 5, 3, 1, 2, 4, 123, 2, 45, 2,87, 43 };
    bsort(ar, sizeof(ar) / sizeof(int), compare_number<int>);

    double dar[] = { 1.5, 1.3, 1.1, 1.2, 1.4 };
    bsort(dar, sizeof(dar) / sizeof(double), compare_number<double>);

    point par[] = { point(1, 2), point(5, 6), point(7, 1), point(2, 2), point(11, 2) };
    bsort(par, sizeof(par) / sizeof(point), compare_points);

    Array <int, 10> arr;
    arr[0] = 1;
    int z = arr[0];

    tstack<int, 10> t;
    t.push(12);
    t.push(3);
    std::cout << t.pop() << std::endl;
    std::cout << t.top() << std::endl;

    tstack<int , 10>* t2 = new tstack<int, 10>;
    return 0;
}
