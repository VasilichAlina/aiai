namespace MO32_2_Vasileva_Meleme.NeuroNet
{
   enum MemoryMode //режим работы памяти
    {
        GET,    //считывание
        SET,    //сохранение памяти
        INIT,   //инициализация памяти
    } 
    enum NeuronType
    {
        Hidden,     //скрытый
        Output     //входной
    }
    enum NetworkMode
    {
        Train,  //обуч
        Test,   //тест
        Demo    //
    }

}
