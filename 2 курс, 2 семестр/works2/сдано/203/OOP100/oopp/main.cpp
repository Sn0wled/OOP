/* 2018 ReVoL Primer Template */
// ОТИ НИЯУ МИФИ
// 1ПО-31Д
// Студент Сафин Михаил
// Объектно-ориентированное программирование
// OOP-203. Абстрактные классы
// 22.10.2023

// main.cpp
// тема: 
#include "class.h"

int main() {
    /*figure* f = new circle(1, 1);
    f->draw();
    f = new square();
    f->draw();
    f->move(2, 2);
    f->draw();*/

    /*paintapp app;
    app.add(new circle(1, 1));
    app.add(new square(2, 2));
    app.item(2)->move(3, 3);
    app.draw();*/

    /*C* c = new C;
    A* a = (A*)c;
    B* b = (B*)a;
    A* aa = static_cast<A*>(c);
    B* bb = static_cast<B*>(c);*/

    paintapp app;
    app.add(new circle(1, 1));
    app.add(new square(2, 2));
    moveable* m = dynamic_cast<moveable*>(app.item(2));
    if (m) m->move(3, 3);
    app.draw();
    return 0;
}
