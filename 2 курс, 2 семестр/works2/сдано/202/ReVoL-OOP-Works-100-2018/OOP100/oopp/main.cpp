/* 2018 ReVoL Primer Template */
// main.cpp
// тема: 
#include "class.h"

void showaddr(figure* o) {
    printf("obj = 0x%p\n", o);
    int vptr = ((int*)o)[0];
    printf("vptr = 0x%p\n", vptr);
    int meth = ((int*)vptr)[0];
    printf("draw = 0x%p\n", meth);
}

int main() {
    figure* f = new circle;
    return 0;
}
