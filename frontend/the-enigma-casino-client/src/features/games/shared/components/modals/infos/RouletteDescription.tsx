const RouletteDescription = ({ isMobile }: { isMobile: boolean }) => (
  <div
    className={`flex flex-col ${
      isMobile ? "gap-6" : "gap-4"
    } text-[1.6rem] leading-snug text-justify whitespace-pre-line`}
  >
    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🎯 Objetivo del juego
      </h3>
      <p>
        Apuesta a un número o grupo de números y espera que la bola caiga en una
        casilla ganadora tras el giro de la ruleta.
      </p>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        ⏱️ Inicio de la ronda
      </h3>
      <ul className="list-disc list-inside">
        <li>Cada ronda comienza con una fase de apuestas de 30 segundos.</li>
        <li>
          Puedes colocar, aumentar, reducir o quitar tus apuestas durante ese
          tiempo.
        </li>
        <li>Solo los jugadores activos pueden apostar.</li>
      </ul>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🧮 ¿Cómo realizar una apuesta?
      </h3>
      <p>
        {isMobile ? (
          <>
            - Pulsa sobre las fichas para elegir una cantidad y luego pulsa en
            el tablero para apostar. <br />
            - Si pulsas donde ya hay una apuesta, sumarás más fichas. <br />- Si
            mantienes pulsado sobre una apuesta, la quitarás.
          </>
        ) : (
          <>
            - Usa clic izquierdo sobre el tablero para apostar. <br />
            - Si haces clic donde ya hay fichas, añadirás más. <br />- Haz clic
            derecho para eliminar la apuesta.
          </>
        )}
      </p>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🎲 Tipos de apuestas disponibles
      </h3>
      <ul className="list-disc list-inside">
        <li>
          <strong>Pleno (Straight):</strong> Un único número del 0 al 36.{" "}
          <em>(Paga x35)</em>
        </li>
        <li>
          <strong>Color:</strong> Rojo o negro. <em>(Paga x1)</em>
        </li>
        <li>
          <strong>Par / Impar (Even / Odd):</strong> Número par o impar (excepto
          el 0). <em>(Paga x1)</em>
        </li>
        <li>
          <strong>Docena:</strong> 1–12, 13–24 o 25–36. <em>(Paga x2)</em>
        </li>
        <li>
          <strong>Columna:</strong> Primera, segunda o tercera columna.{" "}
          <em>(Paga x2)</em>
        </li>
        <li>
          <strong>Alta / Baja:</strong> 1–18 (baja) o 19–36 (alta).{" "}
          <em>(Paga x1)</em>
        </li>
      </ul>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🏆 Resultado y ganancias
      </h3>
      <ul className="list-disc list-inside">
        <li>Si aciertas, recibes la ganancia correspondiente.</li>
        <li>Si no aciertas, pierdes tu apuesta.</li>
        <li>
          Las ganancias se actualizan automáticamente al finalizar el giro.
        </li>
      </ul>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🔚 Cierre de ronda
      </h3>
      <ul className="list-disc list-inside">
        <li>Si ningún jugador apuesta, la ronda se cancela.</li>
        <li>Después del giro hay una pausa antes de la siguiente ronda.</li>
      </ul>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🚷 Inactividad
      </h3>
      <p>
        Si no realizas ninguna apuesta durante dos rondas consecutivas, serás
        expulsado automáticamente de la mesa.
      </p>
    </section>

    <section>
      <h3 className="text-[2rem] font-bold text-[var(--Principal)]">
        🟥⬛🟩 Colores
      </h3>
      <p>
        Los números pueden ser <strong>Rojo</strong>, <strong>Negro</strong> o{" "}
        <strong>Verde</strong> (solo el 0).
      </p>
    </section>
  </div>
);

export default RouletteDescription;
